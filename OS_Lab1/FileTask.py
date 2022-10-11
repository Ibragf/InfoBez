import os

class FileTask:

    def __init__(self, filename):
        self.filename=filename

    def write_to_file(self):

        text=input('Ввод строки:')

        try:
            file = open(self.filename, 'w+')
            try:
                file.write(text)
            except Exception as e:
                print(e)
            finally:
                file.close()
        except Exception as ex:
            print(ex)

        print('Записано\n')

    def read_file(self):
        text=''
        try:
            file=open(self.filename, 'r')
            try:
                text=file.read()
            except Exception as e:
                print(e)
            finally:
                file.close()
        except Exception as ex:
            print(ex)

        print(text, '\n')

    def delete_file(self):
        if os.path.exists(self.filename):
            os.remove(self.filename)
            print('Файл удален\n')