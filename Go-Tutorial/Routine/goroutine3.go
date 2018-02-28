package main

import (
	"fmt"
	"time"
)

func main(){
	ch := make(chan string)
	go sendData(ch)
	go receiveData(ch)
	time.Sleep(1*1e9)
}

func sendData(ch chan string){
	ch <- "beijing"
	ch <- "shanghai"
	ch <- "chengdu"
	close(ch)
}

func receiveData(ch chan string){
	for {
		input, open := <- ch
		if !open{
			break
		}
		fmt.Printf("%s\n", input)
	}
}