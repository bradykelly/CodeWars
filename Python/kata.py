def decipher_this(string):

    cipher_words = string.split()

    plain_words = []
    for i in range(len(cipher_words)):
        digits = []
        otherLetters = []

        chars = list(cipher_words[i])
        for ch in chars:
            if ch.isdigit():
                digits.append(ch)
            elif len(digits) > 0: 
                otherLetters.append(chr(int("".join(digits))))                
                digits.clear()
                otherLetters.append(ch)
            else:
                otherLetters.append(ch)
        if len(digits) > 0:
            otherLetters.append(chr(int("".join(digits)))) 

        if len(otherLetters) > 1:
            temp = otherLetters[len(otherLetters) - 1]
            otherLetters[len(otherLetters) - 1] = otherLetters[1]
            otherLetters[1] = temp
        plain_words.append("".join(otherLetters))

    return " ".join(plain_words)
                
def divisors(num):

    numbers = [i for i in range(1, num + 1)]
    factors = [i for i in range(1, num + 1) if i != 1 and i != num and num % i == 0]    

    if (len(factors) == 0):
        return f"{num} is prime"
    else:
        return factors