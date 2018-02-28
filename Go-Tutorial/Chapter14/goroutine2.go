package main

import (
	"fmt"
	"time"
)

func setData(ch chan string){
	ch <- "beijing"
	ch <- "london"
	ch <- "roma"
}


func getData(ch chan string){
	var input string
	for {
		input = <- ch
		fmt.Printf("%s\n", input)
	}
}

func main(){
	ch := make(chan string)
	go getData(ch)
	go setData(ch)
	time.Sleep(1e9)
}