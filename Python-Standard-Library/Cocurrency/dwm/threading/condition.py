import time
import threading

def consumer(cond):
    t = threading.current_thread()
    with cond:
        cond.wait()
        print('{}: resource is avaiable to the consumer'.format(t.name))
    return

def producer(cond):
    t = threading.current_thread()
    with cond:
        print('{}: Making resource available'.format(t.name))
        cond.notifyAll()
    return

condition = threading.Condition()
c1 = threading.Thread(target=consumer,args=(condition,))
c2 = threading.Thread(target=consumer, args=(condition,))
p = threading.Thread(target=producer, args=(condition,))
c1.start()

time.sleep(1)
c2.start()
time.sleep(2)
p.start()