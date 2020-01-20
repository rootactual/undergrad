def useModule():
    """
    This is a function for Programming Exam 2 to demonstrate module usage.
    """
    import Dierbach_BBmod as db

    db.startItUp()

###
def unmixLimericks(file_name):
    """
    Function to unmix the mash of limited lemmies.
    :return: Dict of information available from Limers.
    """
    End = False

    while not End:
        try:
            ifile = open(file_name, 'r')
            End = True
        except IOError:
            return False

    wopen = open("TwoLimericks.txt", 'w')
    vowels = ('aeiou')
    lims = ''
    l1 = ''
    l2 = ''
    vc = dict()

    with open(file_name) as f:
        lims = f.readlines()
    lims = [x.strip('\n') for x in lims]

    for i, line in enumerate(ifile):
        if i < 0:
            vc = {x:sum([1 for char in vowels if char==x])for x in \
                    'aeiou'}


    for i, line in enumerate(ifile):
        if i % 2 == 1:
            line.append(l1)

    for i, line in enumerate(ifile):
        if i % 2 == 0:
            line.append(l2)

    wopen.write(l1+'\n'+l2)

    wopen.close()
    ifile.close()

    return vc
###
def recursivePowerOf2(expo):
    """
    Function to receive an exponent argument, calc 2 to the power
    recursively, then return result in eloquently returned format... and stuff.
    :return: result of power of 2 recursively
    """
    if expo == 0:
        return 1

    if expo >= 1:
        return 2*recursivePowerOf2(expo-1)

