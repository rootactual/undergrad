emptyStr = ''
wLst = []

#get input
print('Enter words, one at a time.  When finished press return.')
usInp = input('Word please: ')
origW = usInp

#list logic
while usInp != emptyStr:
    z = origW.lower()
    if z[0] in z[1:]:
            wLst.append(usInp)
    y = usInp.lower()
    if y[0] in y[1:]:
            wLst.append(usInp) #why did this take so long....
 
#restart capture logic
    usInp = input('Next word: ')
      
#otherwise ''
if usInp == emptyStr:
    print('\nThe oringinal word entered was "'+ origW+'".')
    print('These entries had characters that matched their first character: ')
    print('\n'.join(wLst))
