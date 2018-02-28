'''
the model of the dmu
'''
class Dmu(object):
    def __init__(self, name, dyct, dpei):
        self._name = name
        self._dyct = dyct
        self._dpei = dpei
    @property
    def name(self):
        return self._name
    @property
    def dyct(self):
        return self._dyct
    @property
    def dpei(self):
        return self._dpei
