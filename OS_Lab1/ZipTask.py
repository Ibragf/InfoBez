import os
import tkinter.filedialog as fd
import zipfile


class ZipTask:

    def __init__(self):
        self.zipfile='1.zip'
        self.filename=''

    def choose_file(self):
        self.filename=fd.askopenfilename(title='Выбрать файл', initialdir='/')

    def add_file(self):
        try:
            self.choose_file()
            if self.filename:
                with zipfile.ZipFile(self.zipfile, mode='w', compression=zipfile.ZIP_DEFLATED) as zf:
                    zf.write(self.filename)
        except Exception as ex:
            print(ex)

    def delete(self):
        if os.path.exists(self.zipfile):
            with zipfile.ZipFile(self.zipfile, mode='a') as zf:
                for file in zf.namelist():
                    if os.path.exists(file): os.remove(file)
            os.remove(self.zipfile)

    def extract(self):
        ROOT_DIR = os.path.abspath(os.curdir)
        if os.path.exists(self.zipfile):
            with zipfile.ZipFile(self.zipfile) as zp:
                zp.extractall(ROOT_DIR)
