# Assignment: Animal
# Create an Animal class and give it the below attributes and methods. 
# Extend the Animal class to two child classes, Dog and Dragon.

class animal(object):
    def __init__ (self, name):
        self.name = name
        self.health = 100

    # actions
    def walk(self, num):
        num *=1
        self.health -= num
        # print 'Health: {}'.format(self.health)
        return self

    def run(self, num):
        num *=5
        self.health -=num
        # print ' Health: {}'.format(self.health)
        return self

    def display(self):
        print 'Animal Name: ' + str(self.name)
        print 'Animal Health: {}'.format(self.health)
        return self

cat = animal('Cat').walk(3).run(2).display()

class dog(animal):
    def __init(self, name):
        super(dog, self).__init__(name)
        self.health = 150
    
    def pet(self, num):
        num *= 5
        self.health += num
        return self

dog1 = dog('Zeus').walk(3).run(2).pet(1).display()

class dragon(animal):
    def __init(self,name):
        super(dragon, self).__init__(name)
        self.health = 170
    
    def fly(self, num):
        num *=10
        self.health -= num
        return self

    def display(self):
        print 'I am a Dragon! Health: {}'.format(self.health)

dragon1 = dragon('Jim').fly(1).display()