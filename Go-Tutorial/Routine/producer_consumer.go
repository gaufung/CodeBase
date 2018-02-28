package main

import "fmt"

func numGen(start, count int, ch chan int){
	for i:= 0; i<count; i++{
		ch <- start
		start = start + count
	}
	close(ch)
}

func numEcho(ch chan int, done chan <- bool){
	for num := range ch{
		fmt.Printf("%d\n", num)
	}
	done <- true
}

func main(){
	start, count := 1, 3
	ch := make(chan int)
	done := make(chan bool)
	go numGen(start, count, ch)
	go numEcho(ch, done)
	<- done
}