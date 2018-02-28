package main

import "fmt"

func producer(start, count int, out chan int){
	for i:=0; i<count; i++{
		out <- start
		start = start+i
	}
	close(out)
}


func consumer(in chan int, done chan bool){
	for num := range in {
		fmt.Printf("%d\n", num)
	}
	done<-true
}

func main(){
	out := make(chan int)
	done := make(chan bool)
	go producer(0, 10, out)
	go consumer(out, done)
	<- done
}
