import time
import multiprocessing

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
    fib(35)
    fib(35)
    return

@profile
def withthread():
    threads = []
    for i in range(2):
        t = multiprocessing.Process(target=fib, args=(35,))
        t.start()
        threads.append(t)
    for t in threads:
        t.join()

nothread()
withthread()
        
