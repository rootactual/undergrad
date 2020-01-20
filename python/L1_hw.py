import time
num = input("What power would'ya like tuh put two to, eh?")
pwr = (2 ** int(num))

print("Processing...")
time.sleep(2)

print("Still processing...")
time.sleep(2)

print("Feeding hamsters.")
time.sleep(1)
print("Ok, ok.  Two to the power of ", int(num), "is ", pwr, ".")

time.sleep(3)

exit()
