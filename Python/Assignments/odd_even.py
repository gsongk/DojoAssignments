# Fun with Functions

# Odd_even function
def odd_even():
    for i in range (1 , 2001):
        if i%2==0:
            print "Number is: ", i, "This is an odd number."
        if i%2 !=0:
            print "Nubmer is: ", i, "This is an even number."
# odd_even()
##################################################################
# Multiply:
a = [2,4,10,16]

def multiply(arr, num):
    newList = []
    for x in arr:
        newList.append(x*num)
        return newList
# print multiply(a, 5)

##########################################################################
# Hack Challenge

def layered_multiples(arr):
    new_array = []
    for x in arr:
        val_arr = []
        for i in range(0,x):
            val_arr.append(1)
            new_array.append(val_arr)
    return new_array
x = layered_multiples(multiply([2,4,5],3))
print x