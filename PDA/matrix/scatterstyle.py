import matplotlib.pyplot as plt
markers = ['.', ',', 'o','v','^',
          '<', '>', '1', '2','3',
          '4', '8', 's', 'p', 'P',
          '*', 'h', 'H', '+', 'x',
          'X', 'D', 'd', '|', '_']
X = range(5)
Y = range(5)
marker_index = 0
for x in X:
    for y in Y:
        plt.scatter([x], [y], marker=markers[marker_index])
        marker_index += 1

plt.show()
        