import os
import xml.etree.ElementTree as xml

class XmlTask:

    def __init__(self):
        self.filename='emploee.xml'

    def createXml(self):
        root=xml.Element('Employee')

        name=xml.SubElement(root, 'name')
        post=xml.SubElement(root,'post')
        city=xml.SubElement(root,'city')

        name.text = input('Ввод имени: ')
        post.text = input('Ввод должности: ')
        city.text = input('Ввод города: ')

        tree=xml.ElementTree(root)
        tree.write(self.filename)

    def readXml(self):
        if os.path.exists(self.filename):
            tree = xml.ElementTree(file=self.filename)
            root = tree.getroot()

            for child in root:
                print(child.tag, ':', child.text)
            print()
        else:
            print('Файл не найден')

    def delete(self):
        if os.path.exists(self.filename):
            os.remove(self.filename)
            print('Deleted\n')
