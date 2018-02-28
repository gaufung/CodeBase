import time
from random import random
from threading import Thread, Semaphore

sema = Semaphore(3)

def foo(tid):
    with sema:
        print('{} acquire sema'.format(tid))
        wt = random() *2
        time.sleep(wt)
    print('{} release sema'.format(tid))
    return

threads = [ ]
for i in range(5):
    t = Thread(target=foo, args=(i,))
    t.start()
    threads.append(t)

for t in threads:
    t.join()