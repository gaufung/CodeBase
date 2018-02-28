import time
import threading

def profile(func):
    def wrapper(*args, **kw):
        import time
        start = time.time()
        func(*args, *kw)
        end = time.time()
        print('Cost:{}'.format(end-start))
        return
    return wrapper


def fib(n):
    if n <= 2:
        return n
    return fib(n-1)+fib(n-2)

@profile
def nothread():
    fib(36)
    fib(36)
    return

@profile
def withthread():
    threads = []
    for i in range(2):
        t = threading.Thread(target=fib, args=(36,))
        t.start()
        threads.append(t)
    for t in threads:
        t.join()

nothread()
withthread()
        
