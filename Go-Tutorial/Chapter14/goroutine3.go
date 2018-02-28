package main

import (
	"fmt"
	//"time"
)

func sendingData(ch chan string){
	ch<- "beijing"
	ch<- "london"
	ch<-"roma"
	close(ch)
}

func receivingData(ch chan string){
	for{
		input, ok := <-ch
		if !ok{
			break
		}
		fmt.Printf("%s\n", input)
	}
}

func main(){
	ch := make(chan string)
	go sendingData(ch)
	go receivingData(ch)

}
