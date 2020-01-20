print("Please enter two integers for processing. \n")
i1 = input("First integer please:")
i2 = input("Second integer please:")

print("\nCalculations:")
print(int(i1), " + ", int(i2), " = ", format(int(i1) + int(i2)), ',')
print(int(i1), " - ", int(i2), " = ", int(i1) - int(i2))
print(int(i1), " * ", int(i2), " = ", int(i1) * int(i2))
print(int(i1), " / ", int(i2), " = ", format((int(i1) / int(i2)), ',.2f'))
print(int(i1), " // ", int(i2), " = ", int(i1) // int(i2))
print(int(i1), " % ", int(i2), " = ", int(i1) % int(i2))
print(int(i1), " ** ", int(i2), " = ", format((int(i1) ** int(i2)), ',.2f'))

exit()
