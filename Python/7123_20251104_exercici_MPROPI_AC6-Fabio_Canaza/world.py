import csv
import os

countryData = [] 

def buildCountryList():
    global countryData
    countryData = []
    base_path = os.path.dirname(os.path.abspath(__file__))
    file_path = os.path.join(base_path, "assets/world-data-2023.csv")

    with open('assets/world-data-2023.csv', newline='', encoding='utf-8') as csvfile:
        reader = csv.DictReader(csvfile)
        for row in reader:
            countryData.append(row)

def getCountryData(country):
    for c in countryData:
        if c['Country'].lower() == country.lower():
            return c
    return {"error": "Country not found"}

def getTop10GDP():
    def parse_gdp(value):
        try:
            return float(value.replace(",", "").strip())
        except:
            return 0.0
        
    sorted_countries = sorted(countryData, key=lambda c: parse_gdp(c.get("GDP", "0")), reverse=True)
    top10 = sorted_countries[:10]
    return list(top10)