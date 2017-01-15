/*
 * dwt_delay.h
 *
 *  Created on: 15 џэт. 2017 у.
 *      Author: asm
 */

#ifndef DWT_DELAY_H_
#define DWT_DELAY_H_

void DWT_Init(void);

uint32_t DWT_Get(void);

void DWT_Delay(uint32_t us); // microseconds

#endif /* DWT_DELAY_H_ */
