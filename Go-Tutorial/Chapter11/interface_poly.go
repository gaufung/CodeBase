package main

import (
	"fmt"
)


type shaper interface {
	area() float32
}


type square struct {
	side float32
}

func (s *square) area() float32{
	return s.side * s.side
}

type rectangle struct {
	width, height float32
}

func (r *rectangle) area() float32{
	return r.height * r.width
}


func main(){
	r := rectangle{3, 4}
	s := square{5}
	shapers :=[]shaper{r, s}
	for n, _ := range shapers{
		fmt.Println("Shaper detail", shapers[n])
		fmt.Printf("Area of the shape is %f\n", shapers[n].area())
	}
}



