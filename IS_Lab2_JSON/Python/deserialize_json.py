# -*- coding: utf-8 -*-
"""
deserialize json
"""
import json
class DeserializeJson:
    # konstruktor
    def __init__(self, filename):
        print("let's deserialize something")
        tempdata = open(filename, encoding="utf8")
        self.data = json.load(tempdata)
    # przykładowe statystyki
    def somestats(self):
        example_stat = 0
        for dep in self.data:
            if dep['typ_JST'] == 'GM' and dep['Województwo'] == 'dolnośląskie':
                example_stat += 1
        print('liczba urzędów miejskich w województwie dolnośląskim: ' + ' ' + str(example_stat))
    def allstats(self):
        statystyki = {}
        for dep in self.data:
            wojewodztwo = dep['Województwo'].strip()
            urzad = dep['typ_JST']
            if wojewodztwo not in statystyki:
                statystyki[wojewodztwo] = {}
            if urzad not in statystyki[wojewodztwo]:
                statystyki[wojewodztwo][urzad] = 0
            statystyki[wojewodztwo][urzad] += 1
        for key in statystyki:
            print(f"{key}: {statystyki[key]}")