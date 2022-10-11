import json
import os.path
from json import JSONEncoder

class JsonTask:

    def __init__(self):
        self.filename='employee.json'

    def toJson(self, employee):
        try:
            jsonString = json.dumps(employee, cls=EmployeeEncoder)
            file=open(self.filename, 'w+')
            file.write(jsonString)
            print('записано\n', jsonString)
        except Exception as ex:
            print(ex)
        finally:
            file.close()

    def fromJson(self):
        if os.path.exists(self.filename):
            try:
                file=open(self.filename, 'r')
                jsonString=file.read()
                data=json.loads(jsonString)

                print('Имя: ', data['name'], 'Должность: ', data['post'], 'Город: ', data['city'],'\n')
            except Exception as ex:
                print(ex,'\n')

    def delete(self):
        if(os.path.exists(self.filename)):
            os.remove(self.filename)
            print('Удалено\n')

class EmployeeEncoder(JSONEncoder):
    def default(self, o):
        return o.__dict__

class Employee:

    def __init__(self):
        self.name='null'
        self.post='null'
        self.city='null'