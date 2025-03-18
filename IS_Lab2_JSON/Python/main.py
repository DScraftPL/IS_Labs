from serialize_json import SerializeJson
from deserialize_json import DeserializeJson
from convert_json_to_yaml import ConvertJsonToYaml

import yaml

tempconffile = open('Assets/basic_config.yaml', encoding="utf8")
confdata = yaml.load(tempconffile, Loader=yaml.FullLoader)
tempconffile.close()

source_type = confdata.get('source', {}).get('type', 'file')
source_path = confdata['paths']['source_folder'] + confdata['paths']['json_source_file']
deserializer = DeserializeJson(source_path)

operations = confdata.get('operations', [])

for operation in operations:
    if operation == 'somestats':
        deserializer.somestats()
    elif operation == 'allstats':
        deserializer.allstats()
    elif operation == 'serialize_json':
        destination = confdata['paths']['source_folder'] + confdata['paths']['json_destination_file']
        serialization_source = confdata['serialization']['source']
        if serialization_source == 'file':
            SerializeJson.run_file(source_path, destination)
        elif serialization_source == 'object':
            SerializeJson.run(deserializer, destination)
    elif operation == 'convert_to_yaml':
        destination = confdata['paths']['source_folder'] + confdata['paths']['yaml_destination_file']
        ConvertJsonToYaml.run(source_path, destination)
    else:
        print(f"Operation unknown: {operation}")

print("End")
