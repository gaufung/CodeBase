package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	for i := 0; i < 10; i++ {
		a := rand.Int()
		fmt.Printf("%d\n", a)
	}
	for i := 0; i < 10; i++ {
		a := rand.Intn(8)
		fmt.Printf("%d\n", a)
	}
	fmt.Println()
	timesn := int64(time.Now().Nanosecond())
	//rand.Seed(timesn)
	for i := 0; i < 10; i++ {
		rand.Seed(timesn)
		fmt.Printf("%2.2f /", 100*rand.Float32())
	}
}
