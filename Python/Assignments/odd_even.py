# Fun with Functions

# Odd_even function
def odd_even():
    for i in range (1 , 2001):
        if i%2==0:
            print "Number is: ", i, "This is an odd number."
        if i%2 !=0:
            print "Nubmer is: ", i, "This is an even number."
# odd_even()

# Multiply:
a = [2,4,10,16]

def multiply():
    for i in range (0, len(a)):
        b = a[i]*5
        print b
# multiply()

# Hack Challenge

x = ([2,4,5],3)
print x

def layered_multiples():
    for i in range (0, len(x)):
        new_array = []
        new_array = str(1) * x[0]
        print new_array

layered_multiples()