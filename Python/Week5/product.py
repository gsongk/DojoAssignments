# Assignment: Product

class product(object):
    def __init__(self, price, name, weight, brand):
        self.price = price
        self.name = name
        self.weight = weight
        self.brand = brand
        self.status = 'For Sale'
        self.tax = 0.15
    
    def sold(self):
        self.status = 'Sold!'
        self.price = self.price + (self.price * self.tax)
        return self
    
    def returnDefective(self, reason):
        self.reason = reason
        self.status = 'Broken: '
        self.status = str(self.status + ' ' + self.reason)
        self.price = 0
        return self

    def returnItems(self):
        self.discount = 0.20
        self.price = self.price - (self.price * self.discount)
        self.status = 'For Sale'
        return self
    
    def display(self):
        print 'Name: ' + str(self.name)
        print 'Brand: ' + str(self.brand)
        print 'Weight: ' + str(self.weight) + ' LBS'
        print 'Total Price: $' + str(self.price)
        print 'Status: ' + self.status
        return self

cellphone = product(1000, 'Universe', 1, 'Samsung' )
cellphone.sold()
cellphone.returnItems()
cellphone.sold()
cellphone.returnItems()
cellphone.returnDefective('Screen')
cellphone.display()

coke = product(1, 'Coke', 1, 'Coke')
coke.sold()
coke.display()
