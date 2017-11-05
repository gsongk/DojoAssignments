# Optional Assignment: Store
# This is my products

#Still Working on this one! 
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

# This is the store
class store(object):
    def __init__(self, location, owner):
        # super(store, self).__init__(price, name, weight, brand)
        self.products= []
        self.location = location
        self.owner = owner

    def addproduct(self, newproduct):
        self.products.append(newproduct)
        return self

    def rmproduct(self, newproduct):
        self.products.pop(newproduct)
        return self

    def inventory(self):
        self.count = 0
        for product in self.products:
            self.count +=1
            print 'Product: ', + self.count
            product.display()
        return self

# Products
cellphone = product(1000, 'Universe', 1, 'Samsung')
coke = product(1, 'Coke', 1, 'Coke')
CandyBar = product(2, 'Butterfingers', 1, 'Nestle')

# Store
taylors = store('SLC', 'Pumpkin')
taylors.addproduct(cellphone).addproduct(coke).inventory()
