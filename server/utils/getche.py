import sys
import termios


def getche():
    fd = sys.stdin.fileno()
    oldattr = termios.tcgetattr(fd)
    newattr = oldattr[:]
    try:
        lflag = ~(termios.ICANON | termios.ECHOCTL)
        newattr[3] &= lflag
        termios.tcsetattr(fd, termios.TCSADRAIN, newattr)
        ch = sys.stdin.read(1)
        if ord(ch) == 127:
            sys.stdout.write('\b \b')
    finally:
        termios.tcsetattr(fd, termios.TCSADRAIN, oldattr)
    return ch
