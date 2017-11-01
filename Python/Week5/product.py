# Assignment: Product
# The owner of a store wants a program to track products. Create a product class to fill the following requirements.

# Product Class:
# Attributes:

# • Price

# • Item Name

# • Weight

# • Brand

# • Status: default "for sale"
# Methods:

# • Sell: changes status to "sold"

# • Add tax: takes tax as a decimal amount as a parameter and returns the price of the item including sales tax

# • Return: takes reason for return as a parameter and changes status accordingly. If the item is being returned because it is defective change status to defective and change price to 0. If it is being returned in the box, like new mark it as for sale. If the box has been opened set status to used and apply a 20% discount.

# • Display Info: show all product details.
# Every method that doesn't have to return something should return self so methods can be chained.