import socket
import random
import time
HOST = '192.168.1.101'
PORT = 50007

serv_adrs = (HOST, PORT)

client = socket.socket (socket.AF_INET, socket.SOCK_DGRAM)

client.bind(serv_adrs)

client.listen()

connection = client.accept()

while True:
    a = random.randrange (3)
    result = str (a)
    print (a)
    connection.send(result.encode('utf-8'), (HOST, PORT))
    #time.sleep (0.2)