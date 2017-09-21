# Making Dictionaries

name = ["Anna", "Eli", "Pariece", "Brendan", "Amy", "Shane", "Oscar"]
favorite_animal = ["horse", "cat", "spider", "giraffe", "ticks", "dolphins", "llamas"]

def make_dict(arr1, arr2):
    new_dict = {}

    if (len(arr1)>len(arr2)):
        new_dict= ['Name', arr1, 'Animal', arr2]
        print new_dict
    elif (len(arr2)>len(arr1)):
        new_dict= ['Animal', arr2, 'Name', arr1]
        print new_dict
    else:
        new_dict= ['Name', arr1, 'Animal', arr2]
        print new_dict
  # your code here
    return new_dict
make_dict(name, favorite_animal)