# Stars

# part I
# x = [4, 6, 1, 3, 5, 7, 25]

# def draw_stars():
#     for i in range(0, len(x)):
#         print "*" * x[i]

# draw_stars()

# part II

x = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]

def draw_stars(arr):
    for i in arr:
        if isinstance(i,int):
            print "*" *i
        elif isinstance(i,str):
            length = len(i)
            letter = i[0].lower()
            print letter * length
draw_stars(x)