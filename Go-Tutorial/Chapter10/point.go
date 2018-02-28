package main

import (
	"fmt"
	"math"
)

type Point struct {
	x float64
	y float64
}

func Abs(p *Point) float64 {
	return math.Sqrt(p.x*p.x+p.y*p.y)
}

func Scale(p *Point, scale int32) {
	p.x = p.x * float64(scale)
	p.y = p.y * float64(scale)
}

func main(){
	p := Point{3.0, 4.0}
	fmt.Printf("The length of point %f\n", Abs(&p))

	Scale(&p, 2)
	fmt.Printf("Scale the point by scale 2: %v\n", p)
}
