# Assignment: Animal
# Create an Animal class and give it the below attributes and methods. Extend the Animal class to two child classes, Dog and Dragon.

# Objective
# The objective of this assignment is to help you understand inheritance. Remember that a class is more than just a collection of properties
#  and methods. If you want to create a new class with attributes and methods that are already defined in another class, you can have this new class inherit from that other class (called the parent) instead of copying and pasting code from the original class. Child classes can access all the attributes and methods of a parent class AND have new attributes and methods of its own, for child instances to call. As we see with Wizard / Ninja / Samurai(that are each descended from Human), we can have numerous unique child classes that inherit from the same parent class.

# Animal Class
# Attributes:

# • name

# • health
# Methods:

# • walk: decreases health by one

# • run: health decreases by five

# • display health: print to the terminal the animal's health.
# Create an instance of the Animal, have it walk() three times, run() twice, and finally 
# displayHealth() to confirm that the health attribute has changed.

# Dog Class
# • inherits everything from Animal
# Attributes:

# • default health of 150
# Methods:

# • pet: increases health by 5
# Have the Dog walk() three times, run() twice, pet() once, and have it displayHealth().

# Dragon Class
# • inherits everything from Animal
# Attributes:

# • default health of 170
# Methods:

# • fly: decreases health by 10

# • display health: prints health by calling the parent method and prints "I am a Dragon"
# Now try creating a new Animal and confirm that it can not call the pet() and fly() methods, and 
# its displayHealth() is not saying 'this is a dragon!'. Also confirm that your Dog class can not fly().
