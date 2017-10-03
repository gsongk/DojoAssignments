#Foo and Bar

def fooBar():
    print "Foo is for prime, Bar is for Square"
    for x in range (100, 100000):
        # if statement - prime
        # print "Foo"
        if (x % 2) != 0 and (x % 3) != 0 and (x % 5) != 0 and (x % 7) != 0 and (x % 9) != 0 and (x % 11) != 0:
            print "prime number", x ,"Foo" 
        # perfect squares
        # if x/x == 1:
        #     print "Bar"

fooBar()