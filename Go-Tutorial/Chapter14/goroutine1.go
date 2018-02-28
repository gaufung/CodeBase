package main

import (
	"fmt"
	"time"
)

func longWait(){
	fmt.Println("Before long wait")
	time.Sleep(5 * 1e9)
	fmt.Println("After long wait")
}


func shortWait(){
	fmt.Println("Before short wait")
	time.Sleep(2 * 1e9)
	fmt.Println("After short wait")
}

func main(){
	fmt.Println("Before main")
	go longWait()
	go shortWait()
	fmt.Println("About to sleep")

	time.Sleep(6 * 1e9)

	fmt.Println("After main")
}
