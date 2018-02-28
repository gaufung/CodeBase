import time
import multiprocessing

value = 0
lock = multiprocessing.Lock()
def getlock():
    global value
    with lock:
        new = value + 1
        time.sleep(0.001)
        value = new
    return

threads = []
for i in range(100):
    t = multiprocessing.Process(target=getlock)
    t.start()
    threads.append(t)
for t in threads:
    t.join()
print(value)