from flask import Flask, request, jsonify, render_template_string
from world import buildCountryList, getCountryData, getTop10GDP

app = Flask(__name__)

# Asegurarse de que los datos estén cargados al comienzo
buildCountryList()

# --- Template de la Pàgina Principal (Pàgina 1) - Estilo Formal y Centrado ---
home_html = """
<!doctype html>
<html>
<head>
    <title>Sistema de Gestión de Datos Globales - Panel Principal</title>
    <style>
        :root {
            --bg-light: #f0f4f7;
            --bg-card: #ffffff;
            --text-dark: #333333;
            --primary-blue: #004d99;
            --secondary-gray: #6c757d;
            --border-light: #cccccc;
            --button-hover: #003366;
            --table-header: #e9ecef;
            --table-border: #dee2e6;
        }

        body { 
            font-family: 'Arial', sans-serif; 
            margin: 0; 
            padding: 40px;
            background-color: var(--bg-light); 
            color: var(--text-dark); 
            min-height: 100vh;
        }

        .container {
            max-width: 900px;
            margin: 0 auto; /* Centra el contenedor principal */
        }

        h1 { 
            font-family: 'Georgia', serif;
            color: var(--primary-blue); 
            border-bottom: 3px solid var(--primary-blue); 
            padding-bottom: 15px;
            font-weight: 300; 
            text-transform: uppercase;
            letter-spacing: 1px;
            text-align: center; /* Centra el título */
        }
        
        h2, h3 { 
            color: var(--text-dark); 
            border-left: 4px solid var(--primary-blue); 
            padding-left: 10px; 
            font-weight: bold;
            margin-top: 30px;
        }

        .nav-link { 
            display: inline-block; 
            padding: 10px 15px; 
            background-color: var(--primary-blue); 
            color: white; 
            text-decoration: none; 
            border-radius: 4px; 
            font-weight: 600;
            transition: background-color 0.3s;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .nav-link:hover { background-color: var(--button-hover); }

        .nav-container {
            text-align: center; /* Centra el enlace de navegación */
            margin-bottom: 25px;
        }

        hr { border: 0; border-top: 1px solid var(--border-light); margin: 30px 0; }
        
        form, .info-box { 
            background: var(--bg-card); 
            padding: 30px; 
            border-radius: 8px; 
            box-shadow: 0 4px 10px rgba(0,0,0,0.08); 
            border: 1px solid var(--border-light);
            margin-bottom: 25px;
        }

        select, input[type="number"] { 
            padding: 10px; 
            border-radius: 4px; 
            border: 1px solid var(--border-light); 
            background-color: var(--bg-light); 
            color: var(--text-dark);
            transition: all 0.2s;
        }
        
        button { 
            padding: 10px 15px;
            border-radius: 4px; 
            background-color: var(--primary-blue); 
            color: white; 
            cursor: pointer; 
            font-weight: 600;
            border: none;
            box-shadow: 0 1px 3px rgba(0,0,0,0.1);
            transition: background-color 0.3s;
        }
        button:hover { background-color: var(--button-hover); }

        /* Estilos de Tabla de Resultados */
        .results-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }
        .results-table th, .results-table td {
            border: 1px solid var(--table-border);
            padding: 12px;
            text-align: left;
        }
        .results-table th {
            background-color: var(--table-header);
            color: var(--primary-blue);
            font-weight: bold;
            text-transform: uppercase;
            font-size: 0.9em;
        }
        .results-table tr:nth-child(even) {
            background-color: #f8f9fa;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Sistema de Análisis de Indicadores Globales</h1>

        <div class="nav-container">
            <!-- Enlace a la Pàgina 2 de Filtrado -->
            <a href="/filter_countries" class="nav-link">Módulo de Filtrado Analítico</a>
        </div>

        <hr>
        
        <!-- Consulta Rápida -->
        <form action="/" method="POST">
            <h3>1. Consulta Rápida por País</h3>
            <label for="country" style="font-weight: bold;">Seleccione País:</label>
            <select id="country" name="country" required>
                <option value="">-- Seleccionar un País --</option>
                {% for country in countries %}
                    <option value="{{country}}">{{country}}</option>
                {% endfor %}
            </select>
            <button type="submit">Obtener Datos</button>
        </form>

        <!-- Top 10 -->
        <form action="/top10" method="GET">
            <h3>2. Clasificación de Variables Clave</h3>
            <button type="submit">Mostrar Top 10 por Producto Interno Bruto (PIB) [JSON]</button>
        </form>

        {% if country_data %}
            <div class="info-box">
                <h2>Reporte Analítico para {{ country_data.Country }}</h2>
                <table class="results-table">
                    <thead>
                        <tr>
                            <th>Indicador</th>
                            <th>Valor</th>
                        </tr>
                    </thead>
                    <tbody>
                        {% for key, value in country_data.items() %}
                            {% if key != 'Country' %}
                            <tr>
                                <td>{{ key | replace("_", " ") | title }}</td>
                                <td>{{ value }}</td>
                            </tr>
                            {% endif %}
                        {% endfor %}
                    </tbody>
                </table>
            </div>
        {% endif %}
    </div>
</body>
</html>
"""

# --- Template de la Pàgina de Filtrado (Pàgina 2) - Estilo Formal y Centrado ---
filter_html = """
<!doctype html>
<html>
<head>
    <title>Herramienta de Búsqueda por Rango de Indicadores</title>
    <style>
        :root {
            --bg-light: #f0f4f7;
            --bg-card: #ffffff;
            --text-dark: #333333;
            --primary-blue: #004d99;
            --secondary-gray: #6c757d;
            --border-light: #cccccc;
            --button-hover: #003366;
            --error-red: #cc0000;
            --table-header: #e9ecef;
            --table-border: #dee2e6;
        }

        body { 
            font-family: 'Arial', sans-serif; 
            margin: 0; 
            padding: 40px;
            background-color: var(--bg-light); 
            color: var(--text-dark); 
            min-height: 100vh;
        }

        .container {
            max-width: 900px;
            margin: 0 auto; /* Centra el contenedor principal */
        }

        h1 { 
            font-family: 'Georgia', serif;
            color: var(--primary-blue); 
            border-bottom: 3px solid var(--primary-blue); 
            padding-bottom: 15px;
            font-weight: 300; 
            text-transform: uppercase;
            letter-spacing: 1px;
            text-align: center;
        }
        
        h2, h3 { 
            color: var(--text-dark); 
            border-left: 4px solid var(--primary-blue); 
            padding-left: 10px; 
            font-weight: bold;
            margin-top: 30px;
        }

        .nav-link { 
            display: inline-block; 
            padding: 10px 15px; 
            background-color: var(--primary-blue); 
            color: white; 
            text-decoration: none; 
            border-radius: 4px; 
            font-weight: 600;
            transition: background-color 0.3s;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .nav-link:hover { background-color: var(--button-hover); }

        .nav-container {
            text-align: center; /* Centra el enlace de navegación */
            margin-bottom: 25px;
        }

        hr { border: 0; border-top: 1px solid var(--border-light); margin: 30px 0; }
        
        form { 
            background: var(--bg-card); 
            padding: 30px; 
            border-radius: 8px; 
            box-shadow: 0 4px 10px rgba(0,0,0,0.08); 
            border: 1px solid var(--border-light);
            margin-bottom: 25px;
            max-width: 500px;
            margin-left: auto;
            margin-right: auto;
        }

        input[type="number"], select { 
            padding: 10px; 
            border-radius: 4px; 
            border: 1px solid var(--border-light); 
            background-color: var(--bg-light); 
            color: var(--text-dark);
            width: 100%; 
            box-sizing: border-box; 
            margin-top: 5px;
            margin-bottom: 10px;
            transition: border-color 0.2s;
        }

        input[type="number"]:focus, select:focus {
            outline: none;
            border-color: var(--primary-blue);
            box-shadow: 0 0 5px rgba(0, 77, 153, 0.3);
        }
        
        button[type="submit"] { 
            background-color: var(--primary-blue); 
            color: white; 
            cursor: pointer; 
            border: none;
            font-weight: 600;
            padding: 12px;
            width: 100%;
            border-radius: 4px;
            margin-top: 10px; 
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
            transition: background-color 0.3s;
        }
        button[type="submit"]:hover { background-color: var(--button-hover); }

        .error { 
            color: var(--error-red); 
            font-weight: bold; 
            padding: 15px; 
            border: 1px solid var(--error-red); 
            background-color: #fff0f0; 
            border-radius: 4px; 
            text-align: center;
            max-width: 500px;
            margin: 20px auto;
        }
        
        .results { 
            background: var(--bg-card); 
            padding: 25px; 
            border-radius: 8px; 
            box-shadow: 0 4px 10px rgba(0,0,0,0.08); 
            border: 1px solid var(--border-light);
            margin-top: 25px;
        }

        .results-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }
        .results-table th, .results-table td {
            border: 1px solid var(--table-border);
            padding: 12px;
            text-align: left;
        }
        .results-table th {
            background-color: var(--table-header);
            color: var(--primary-blue);
            font-weight: bold;
            text-transform: uppercase;
            font-size: 0.9em;
        }
        .results-table tr:nth-child(even) {
            background-color: #f8f9fa;
        }
        
        .no-results {
            padding: 15px;
            border: 1px solid var(--border-light);
            background-color: var(--bg-light);
            border-radius: 4px;
            text-align: center;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Módulo de Filtrado Analítico por Indicador</h1>

        <div class="nav-container">
            <a href="/" class="nav-link">Regresar al Panel Principal</a>
        </div>

        <hr>

        <form action="/filter_countries" method="POST">
            <h3>Definición de Criterios de Búsqueda</h3>

            <div style="margin-bottom: 15px;">
                <label for="variable" style="display: block; font-weight: bold; margin-bottom: 5px;">Seleccione Indicador:</label>
                <select id="variable" name="variable" required>
                    <option value="GDP" {% if selected_variable_key == 'GDP' %}selected{% endif %}>Producto Interno Bruto (PIB)</option>
                    <option value="Population" {% if selected_variable_key == 'Population' %}selected{% endif %}>Población Total</option>
                    <option value="Life_Expectancy" {% if selected_variable_key == 'Life_Expectancy' %}selected{% endif %}>Esperanza de Vida (Años)</option>
                    <option value="Total_Area" {% if selected_variable_key == 'Total_Area' %}selected{% endif %}>Superficie Total (km²)</option>
                </select>
            </div>

            <div style="margin-bottom: 15px;">
                <label for="min_val" style="display: block; font-weight: bold; margin-bottom: 5px;">Valor Mínimo (Umbral Inferior):</label>
                <input type="number" id="min_val" name="min_val" step="any" required value="{{ min_val if min_val is not none else '' }}">
            </div>

            <div style="margin-bottom: 20px;">
                <label for="max_val" style="display: block; font-weight: bold; margin-bottom: 5px;">Valor Máximo (Umbral Superior):</label>
                <input type="number" id="max_val" name="max_val" step="any" required value="{{ max_val if max_val is not none else '' }}">
            </div>
            
            <button type="submit">Ejecutar Análisis y Filtrado</button>
        </form>

        {% if error_message %}
            <p class="error">{{ error_message }}</p>
        {% endif %}

        {% if filtered_countries is not none and not error_message %}
            <div class="results">
                <h2>Países que cumplen con el criterio: {{ selected_variable_display }} ({{ min_val }} - {{ max_val }})</h2>
                {% if filtered_countries|length > 0 %}
                    <table class="results-table">
                        <thead>
                            <tr>
                                <th>Nº</th>
                                <th>País</th>
                            </tr>
                        </thead>
                        <tbody>
                            {% for country_name in filtered_countries %}
                                <tr>
                                    <td>{{ loop.index }}</td>
                                    <td>{{ country_name }}</td>
                                </tr>
                            {% endfor %}
                        </tbody>
                    </table>
                {% else %}
                    <p class="no-results">No se encontraron países que cumplan con los criterios especificados.</p>
                {% endif %}
            </div>
        {% endif %}
    </div>
</body>
</html>
"""


@app.route("/", methods=["GET", "POST"])
def index():
    from world import countryData
    
    countries = sorted([country['Country'] for country in countryData])
    country_info = None  

    if request.method == "POST":
        selected_country = request.form.get("country")
        country_info = getCountryData(selected_country) 
    
    return render_template_string(home_html, countries=countries, country_data=country_info)


@app.route("/top10", methods=["GET"])
def top10():
    data = getTop10GDP()
    return jsonify(data)


@app.route("/filter_countries", methods=["GET", "POST"])
def filter_countries():
    from world import countryData
    
    filtered_list = None
    error_msg = None
    selected_var_key = "GDP"
    selected_var_display = ""
    min_val_display = None
    max_val_display = None

    if request.method == "POST":
        selected_variable = request.form.get("variable")
        min_val_str = request.form.get("min_val")
        max_val_str = request.form.get("max_val")
        
        selected_var_key = selected_variable 

        variable_map = {
            "GDP": "Producto Interno Bruto (PIB)",
            "Population": "Población Total",
            "Life_Expectancy": "Esperanza de Vida (Años)",
            "Total_Area": "Superficie Total (km²)"
        }
        selected_var_display = variable_map.get(selected_variable, selected_variable)

        try:
            min_val = float(min_val_str)
            max_val = float(max_val_str)
            
            min_val_display = min_val
            max_val_display = max_val

            if min_val > max_val:
                error_msg = f"Error de Lógica: El valor mínimo ({min_val}) no puede ser superior al valor máximo ({max_val}). Por favor, revise los parámetros."
                filtered_list = []
            else:
                filtered_list = []
                for country in countryData:
                    value_str = str(country.get(selected_variable, 0)).replace(',', '').replace(' ', '')
                    
                    try:
                        value = float(value_str)
                        if min_val <= value <= max_val:
                            filtered_list.append(country['Country'])
                    except ValueError:
                        continue

        except ValueError:
            error_msg = "Error de Validación: Asegúrese de que los valores mínimo y máximo introducidos sean números válidos."
            filtered_list = []
        
    return render_template_string(
        filter_html, 
        filtered_countries=filtered_list, 
        error_message=error_msg, 
        selected_variable_key=selected_var_key,
        selected_variable_display=selected_var_display,
        min_val=min_val_display,
        max_val=max_val_display
    )


if __name__ == "__main__":
    app.run(debug=True, port=5050)