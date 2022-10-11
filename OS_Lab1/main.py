from FileSystemInfo import FileSystemInfo
from FileTask import FileTask
from JsonTask import Employee, JsonTask
from XmlTask import XmlTask
from ZipTask import ZipTask


def zip_menu():
    choice = '-1'
    try:
        while int(choice) != 0:
            print('0 - Возврат')
            print('1 - Добавить файл')
            print('2 - Разархивировать')
            print('3 - Удаление')
            print('\n')

            choice = input()
            int_choice = int(choice)
            zipTask=ZipTask()

            if int_choice == 0: return
            if int_choice == 1: zipTask.add_file()
            if int_choice == 2: zipTask.extract()
            if int_choice == 3: zipTask.delete()
    except Exception as ex:
        print(ex)

def xml_menu():
    choice = '-1'
    try:
        while int(choice) != 0:
            print('0 - Возврат')
            print('1 - Новый объект')
            print('2 - Чтение xml')
            print('3 - Удаление файла')
            print('\n')

            choice = input()
            int_choice = int(choice)
            xmlTask=XmlTask()

            if int_choice == 0: return
            if int_choice == 1: xmlTask.createXml()
            if int_choice == 2: xmlTask.readXml()
            if int_choice == 3: xmlTask.delete()
    except Exception as ex:
        print(ex)

def json_menu():
    choice = '-1'
    try:
        while int(choice) != 0:
            print('0 - Возврат')
            print('1 - Новый объект')
            print('2 - Чтение json')
            print('3 - Удаление файла')
            print('\n')

            choice = input()
            int_choice = int(choice)
            jsontask = JsonTask()

            if int_choice == 0: return
            if int_choice == 1:
                employee = Employee()
                print('Ввод имени: ')
                employee.name=input()
                print('Ввод должности: ')
                employee.post=input()
                print('Ввод города: ')
                employee.city=input()

                jsontask.toJson(employee)

            if int_choice == 2: jsontask.fromJson()
            if int_choice == 3: jsontask.delete()

    except Exception as ex:
        print(ex)

def files_menu():

    filetask=FileTask('file.txt')
    choice='-1'
    try:
        while int(choice) != 0:
            print('0 - Возврат')
            print('1 - Запись в файл')
            print('2 - Чтение файла')
            print('3 - Удаление файла')
            print('\n')

            choice=input()
            int_choice = int(choice)

            if int_choice==0: return
            if int_choice==1: filetask.write_to_file()
            if int_choice==2: filetask.read_file()
            if int_choice==3: filetask.delete_file()

    except Exception as ex:
        print(ex)

def menu():

    choice='-1'
    try:
        while int(choice) != 0:
            print('0 - Завершение')
            print('1 - Информация о дисках')
            print('2 - Работа с файлом')
            print('3 - JSON')
            print('4 - XML')
            print('5 - ZIP')
            print('\n')

            choice=int(input())

            if choice==0: break
            if choice==1:
                fileSystem=FileSystemInfo()
                fileSystem.FillDiskInfo()
            if choice==2: files_menu()
            if choice==3: json_menu()
            if choice==4: xml_menu()
            if choice==5: zip_menu()
    except Exception as ex:
        menu()

if __name__ == '__main__':
    menu()




