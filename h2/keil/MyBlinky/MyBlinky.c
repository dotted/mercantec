/**************************************************************/ 
/* myBlinky: Very Simple LED Flasher  */ 
/**************************************************************/ 
/* This file was derived from uVision/ARM development tools. */ 
/* */ 
/* Dr. Mark Fisher, CMP, UEA, Norwich, UK.  */ 
/* Last updated 29.06.10  */ 
/**************************************************************/ 
#include <stm32f10x_cl.h> 

// unsigned long int, declare variable used to store current tick
// use volatile keyword inorder to avoid the compiler making optimizations involving msTicks var
// from http://www.keil.com/support/man/docs/gsac/gsac_systicktimer.htm
volatile uint32_t msTicks;                  // Counts 1ms timeTicks

// Is automatically called (we observed, but not sure from where) at every tick,
// Increments msTicks by 1
void SysTick_Handler (void)  {
  msTicks++;                                // Increment counter
}

//wait function
// param ms: milliseconds to wait
void wait (uint32_t ms) {
	//set current tick so we know at what tick we started the wait function
	uint32_t startTick = msTicks;
	//calaculate the end tick by adding startTick and ms
	uint32_t stopTick = startTick+ms;
	while(stopTick >= msTicks)
		//NOOP
		;
}

//main function
int main (void) { 
	const unsigned long led_mask = 1<<11; 
	SystemInit();
	SysTick_Config (SystemFrequency/1000);    // Configure the SYSTICK

	/* Setup GPIO for LEDs */ 
	RCC->APB2ENR |= 1 << 6; /* Enable GPIOE clock */ 
	GPIOE->CRH = 0x33333333; /* Configure the GPIO for LEDs */ 
	while (1) { /* Loop forever */ 
		GPIOE->BSRR = led_mask; /* Turn LED on */ 
		wait(1337); /* wait */ 
		GPIOE->BSRR = led_mask << 16; /* Turn LED off*/ 
		wait(1337); /* wait */ 
	} 
}