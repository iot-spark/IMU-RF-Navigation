/*
 * print.c
 *
 *  Created on: 28 џэт. 2017 у.
 *      Author: asm
 */

#include <stdbool.h>
#include "stm32f4xx_hal.h"
#include "usart.h"

static char num_buff[20] = {0,}, split[1] = ";", nl[1] = {'\n'};

bool print_float(float num, bool add_split, bool add_nl)
{
	int lng = -1;

	lng = sprintf(num_buff, "%8.4f", num);

	if (add_split)
	{
		HAL_UART_Transmit(&huart6, split, 1, 100);
	}

	HAL_UART_Transmit(&huart6, num_buff, lng, 100);

	if (add_nl)
	{
		HAL_UART_Transmit(&huart6, nl, 1, 100);
	}

	return true;
}

void print_motion7(uint32_t tick, float ax, float ay, float az, float gx, float gy, float gz, float t)
{
	print_float(tick*0.001, false, false);

	print_float(ax, true, false);
	print_float(ay, true, false);
	print_float(az, true, false);

	print_float(gx, true, false);
	print_float(gy, true, false);
	print_float(gz, true, false);

	print_float(t, true, true);
}
