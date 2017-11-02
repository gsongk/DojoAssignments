# Assignment: Bike
# Create a new class called Bike with the following properties/attributes:

# price
# max_speed
# miles
# Create 3 instances of the Bike class.

class bike(object):
    def __init__(self, price, max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0
    
    def displayInfo(self):
        print 'Price: $' + str(self.price)
        print 'Max speed: ' + str(self.max_speed) + ' mph'
        print 'Total miles: ' + str(self.miles) + ' miles'

    def ride(self):
        print 'Driving'
        self.miles +=10
    
    def reverse(self):
        print 'Reversing'
        if self.miles >= 5:
            self.miles -=5

bike1 = bike(99.99, 12)
bike1.ride()
bike1.ride()
bike1.ride()
bike1.reverse()
bike1.displayInfo()

bike2 = bike(139.99, 20)
bike2.ride()
bike2.ride()
bike2.reverse()
bike2.reverse()
bike2.displayInfo()