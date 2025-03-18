# -*- coding: utf-8 -*-
"""
json to yaml converter
"""
import json
import yaml

class ConvertJsonToYaml:
    # @staticmethod
    # def run(deserializeddata, destinationfilelocaiton):
    #     print("let's convert something")
    #     with open(destinationfilelocaiton, 'w', encoding='utf-8') as f:
    #         yaml.dump(deserializeddata, f, allow_unicode=True)
    #     print("it is done")
    # @staticmethod
    def run(filelocation, destinationfilelocation):
        print("let's convert yaml")
        with open(destinationfilelocation, 'w', encoding='utf-8') as destination:
            with open(filelocation, "r", encoding='utf-8') as source:
                data = json.load(source)
                yaml.dump(data, destination, allow_unicode=True)