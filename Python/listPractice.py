# String and List Practice

# find and replace
# words = "It's thanksgiving day. It's my birthday,too!"
# find = "day"
# replace = "month"

# print words.find(find)
# print words.replace(find, replace)

# Min and Max   
# x = [2,54,-2,7,12,98]
# high = max(x)
# low = min(x)

# print high
# print low

# First and Last
# x = ["hello",2,54,-2,7,12,98,"world"]

# x.sort()
# print x[6:]

# New List
x = [19,2,54,-2,7,12,98,32,10,-3,6]
x.sort()
x[0] = x[:5]
del x[1:5]

print x