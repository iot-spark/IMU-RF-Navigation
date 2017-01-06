### General Info ###
STM32F4 family has the following timers:  
+ *TIM1*, *TIM8* - 4ch, 16bit, PWM signal generation and Input Capture
+ *TIM2*, *TIM5* - 4ch, 16 or 32bit, PWM signal generation and Input Capture
+ *TIM9* to *TIM14* - 2ch, 16bit, PWM signal generation and Input Capture
+ *TIM6*, *TIM7* - 2ch, 16bit, Basic Timers

[Comparison Table](http://www.farrellf.com/projects/hardware/2012-08-11_STM32F4_Basics:_Timers_%28Part_1%29)

### MPU-9250 Communication Protocol (I2C) ###
Refering to [MPU-9250 datasheet](https://www.invensense.com/wp-content/uploads/2015/02/PS-MPU-9250A-01-v1.1.pdf).
**Note:** *Similar protocol should apply to MPU-6050. The only difference is the lack of Mag and different Register Map (possibly).*

+ Start Condition (S) == ? amount of time
+ 7 bit == Address 0b110100(0|1) - Two Deives on one line OR Multiple Devices with AD0 hack
+ 1 bit == R/W bit
+ 1 SCL pulse == ACK
+ 8 bit + 1 bit == 1 byte of Payload + ACK bit
+ 9bit N times == *Next Payload Chunks*
+ Stop  Condition (P) == ? amount of time

**Page 34**:

> To write the internal MPU-9250 registers, the master transmits the start condition (S), followed by the I2C
address and the write bit (0). At the 9th clock cycle (when the clock is high), the MPU-9250 acknowledges the
transfer. Then the master puts the register address (RA) on the bus. After the MPU-9250 acknowledges the
reception of the register address, the master puts the register data onto the bus. This is followed by the ACK
signal, and data transfer may be concluded by the stop condition (P). To write multiple bytes after the last ACK
signal, the master can continue outputting data rather than transmitting a stop signal. In this case, the MPU-
9250 automatically increments the register address and loads the data to the appropriate register. The
following figures show single and two-byte write sequences. 

**Page 35**:

> To read the internal MPU-9250 registers, the master sends a start condition, followed by the I2C address and
a write bit, and then the register address that is going to be read. Upon receiving the ACK signal from the MPU-
9250, the master transmits a start signal followed by the slave address and read bit. As a result, the MPU-
9250 sends an ACK signal and the data. The communication ends with a not acknowledge (NACK) signal and
a stop bit from master. The NACK condition is defined such that the SDA line remains high at the 9th clock
cycle. The following figures show single and two-byte read sequences.

### MPU-9250 Payload ###
Refering to [MPU-9250 Lib Code](https://github.com/kriswiner/MPU-9250/blob/master/MPU9250BasicAHRS.ino) and [MPU-9250 Register Map datasheet](https://cdn.sparkfun.com/assets/learn_tutorials/5/5/0/MPU-9250-Register-Map.pdf).

```c
#define ACCEL_XOUT_H     0x3B
#define ACCEL_XOUT_L     0x3C
#define ACCEL_YOUT_H     0x3D
#define ACCEL_YOUT_L     0x3E
#define ACCEL_ZOUT_H     0x3F
#define ACCEL_ZOUT_L     0x40
#define TEMP_OUT_H       0x41
#define TEMP_OUT_L       0x42
#define GYRO_XOUT_H      0x43
#define GYRO_XOUT_L      0x44
#define GYRO_YOUT_H      0x45
#define GYRO_YOUT_L      0x46
#define GYRO_ZOUT_H      0x47
#define GYRO_ZOUT_L      0x48
```

Pure Payload: 14 bytes.  
SCL pulses per 1 byte: 18.  
Total SCL pulses: 14 * 18 [+ ? pulses for (S) and (P)] == **252 pulses** [+ (S) and (P)].  
Total time at 400kHz (pps): 252 / 400k == 0.63msec.  
Total time for 4 sensors (MPU-9250 or MPU-6050): 0.63msec * 4 == 2.52msec [+ (S) and (P), other delay due to Pins Toggling for AD0 hack and similar things].  
Total time for 4 Sensors approx.: **5msec**.  

Taking **10msec** period for Main Timer Period as Initial Approximation.

**TODO 1**: *Find out how to get Mag Payload.*  
**TODO 2**: *Evaluate Approx. the time needed for Kalman Filter calculations.*  
