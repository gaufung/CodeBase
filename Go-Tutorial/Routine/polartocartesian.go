package main

import (
	"runtime"
	"fmt"
	"math"
	"bufio"
	"os"
	"strings"
	"strconv"
)

type polar struct {
	radius float64
	theta float64
}

type cartesian struct {
	x float64
	y float64
}

const result = "Polar: radius=%.02f angle=%.02f degrees -- Cartesian: x=%.02f y=%.02f\n"

var prompt = "Enter a radius and an angle (in degrees), e.g., 12.5 90, " + "or %s to quit."

func init(){
	if runtime.GOOS == "windows"{
		prompt = fmt.Sprintf(prompt, "Ctrl+Z, Enter")
	}else{ // Unix like
		prompt = fmt.Sprintf(prompt, "Ctrl+D")
	}
}

func main(){
	questions := make(chan polar)
	defer  close(questions)
	answer := createSolver(questions)
	defer  close(answer)
	interact(questions, answer)
}


func createSolver(questions chan polar) chan cartesian{
	answer := make(chan cartesian)
	go func(){
		for {
			polarCoord := <- questions
			theta := polarCoord.theta / 180 * math.Pi
			x:= polarCoord.radius * math.Cos(theta)
			y:= polarCoord.radius * math.Sin(theta)
			answer <- cartesian{x, y}

		}
	}()
	return answer
}

func interact(question chan polar, answer chan cartesian){
	reader:= bufio.NewReader(os.Stdin)
	fmt.Println(prompt)
	for{
		fmt.Printf("radius and angle: ")
		line, err := reader.ReadString('\n')
		if err != nil {
			break
		}
		line = line[:len(line)-1]
		if numbers := strings.Fields(line); len(numbers)==2{
			polars, err :=floatForString(numbers)
			if err != nil {
				fmt.Println(os.Stderr, "invalid error")
				continue
			}
			question <- polar{polars[0], polars[1]}
			coord := <- answer
			fmt.Printf(result, polars[0], polars[1], coord.x, coord.y)
		}else{
			fmt.Fprintln(os.Stderr, "invalid input")
		}
	}
	fmt.Println()
}

func floatForString(numbers []string)([] float64, error){
	var floats []float64
	for _, number := range numbers{
		if x, err := strconv.ParseFloat(number, 64); err!=nil{
			return nil, err
		}else{
			floats = append(floats, x)
		}
	}
	return floats, nil
}