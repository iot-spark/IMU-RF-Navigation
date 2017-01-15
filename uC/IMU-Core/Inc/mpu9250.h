/*
MPU9250.h
Brian R Taylor
brian.taylor@bolderflight.com
2017-01-03

Copyright (c) 2016 Bolder Flight Systems

Permission is hereby granted, free of charge, to any person obtaining a copy of this software
and associated documentation files (the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute,
sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#ifndef MPU9250_h
#define MPU9250_h

#include "stm32f4xx_hal.h"
#include "stm32f4xx_hal_gpio.h"

// DELAY
#define SYS_CLK 168 // SYS Clock in MHz
#define DELAY_MS(millis) HAL_Delay(millis)
#define DELAY_uS(micros) for(uint32_t i = 0; i < micros; i++){}

// SPI Defines
#define SPI_CS GPIOD, GPIO_PIN_15
#define CS_ON HAL_GPIO_WritePin(SPI_CS, GPIO_PIN_RESET);
#define CS_OFF HAL_GPIO_WritePin(SPI_CS, GPIO_PIN_SET);

#define MPU_SPI_TX(data) HAL_SPI_Transmit_DMA(&hspi1, data, 1)
#define MPU_SPI_RX(buff) HAL_SPI_(&hspi1, buff, 1)
#define USE_SPI 1		// Use SPI rather I2C
#define USE_SPI_HS 0    // Configure SPI with High Speed
#define SPI_READ 0x80;

// I2C Defines
#define I2C_MPU9250_ADR 0x68

typedef enum
{
    GYRO_RANGE_250DPS,
    GYRO_RANGE_500DPS,
    GYRO_RANGE_1000DPS,
    GYRO_RANGE_2000DPS
} mpu9250_gyro_range;

typedef enum
{
    ACCEL_RANGE_2G,
    ACCEL_RANGE_4G,
    ACCEL_RANGE_8G,
    ACCEL_RANGE_16G
}mpu9250_accel_range;

typedef enum
{
    DLPF_BANDWIDTH_184HZ,
    DLPF_BANDWIDTH_92HZ,
    DLPF_BANDWIDTH_41HZ,
    DLPF_BANDWIDTH_20HZ,
    DLPF_BANDWIDTH_10HZ,
    DLPF_BANDWIDTH_5HZ
}mpu9250_dlpf_bandwidth;

int32_t Init_MPU9250(mpu9250_accel_range accelRange, mpu9250_gyro_range gyroRange);
int32_t setFilt(mpu9250_dlpf_bandwidth bandwidth, uint8_t SRD);
int32_t enableInt(uint8_t enable);

void getAccel(float* ax, float* ay, float* az);
void getGyro(float* gx, float* gy, float* gz);
void getMag(float* hx, float* hy, float* hz);
void getTemp(float *t);
void getMotion6(float* ax, float* ay, float* az, float* gx, float* gy, float* gz);
void getMotion7(float* ax, float* ay, float* az, float* gx, float* gy, float* gz, float* t);
void getMotion9(float* ax, float* ay, float* az, float* gx, float* gy, float* gz, float* hx, float* hy, float* hz);
void getMotion10(float* ax, float* ay, float* az, float* gx, float* gy, float* gz, float* hx, float* hy, float* hz, float* t);

void getAccelCounts(int16_t* ax, int16_t* ay, int16_t* az);
void getGyroCounts(int16_t* gx, int16_t* gy, int16_t* gz);
void getMagCounts(int16_t* hx, int16_t* hy, int16_t* hz);
void getTempCounts(int16_t* t);
void getMotion6Counts(int16_t* ax, int16_t* ay, int16_t* az, int16_t* gx, int16_t* gy, int16_t* gz);
void getMotion7Counts(int16_t* ax, int16_t* ay, int16_t* az, int16_t* gx, int16_t* gy, int16_t* gz, int16_t* t);
void getMotion9Counts(int16_t* ax, int16_t* ay, int16_t* az, int16_t* gx, int16_t* gy, int16_t* gz, int16_t* hx, int16_t* hy, int16_t* hz);
void getMotion10Counts(int16_t* ax, int16_t* ay, int16_t* az, int16_t* gx, int16_t* gy, int16_t* gz, int16_t* hx, int16_t* hy, int16_t* hz, int16_t* t);

// MPU9250 registers
#define ACCEL_OUT 0x3B
#define GYRO_OUT 0x43
#define TEMP_OUT 0x41
#define EXT_SENS_DATA_00 0x49

#define ACCEL_CONFIG 0x1C
#define ACCEL_FS_SEL_2G 0x00
#define ACCEL_FS_SEL_4G 0x08
#define ACCEL_FS_SEL_8G 0x10
#define ACCEL_FS_SEL_16G 0x18

#define GYRO_CONFIG 0x1B
#define GYRO_FS_SEL_250DPS 0x00
#define GYRO_FS_SEL_500DPS 0x08
#define GYRO_FS_SEL_1000DPS 0x10
#define GYRO_FS_SEL_2000DPS 0x18

#define ACCEL_CONFIG2 0x1D
#define ACCEL_DLPF_184 0x01
#define ACCEL_DLPF_92 0x02
#define ACCEL_DLPF_41 0x03
#define ACCEL_DLPF_20 0x04
#define ACCEL_DLPF_10 0x05
#define ACCEL_DLPF_5 0x06

#define CONFIG 0x1A
#define GYRO_DLPF_184 0x01
#define GYRO_DLPF_92 0x02
#define GYRO_DLPF_41 0x03
#define GYRO_DLPF_20 0x04
#define GYRO_DLPF_10 0x05
#define GYRO_DLPF_5 0x06

#define SMPDIV 0x19

#define INT_PIN_CFG 0x37
#define INT_ENABLE 0x38
#define INT_DISABLE 0x00
#define INT_PULSE_50US 0x00
#define INT_RAW_RDY_EN 0x01

#define PWR_MGMNT_1 0x6B
#define PWR_RESET 0x80
#define CLOCK_SEL_PLL 0x01

#define PWR_MGMNT_2 0x6C
#define SEN_ENABLE 0x00

#define USER_CTRL 0x6A
#define I2C_MST_EN 0x20
#define I2C_MST_CLK 0x0D
#define I2C_MST_CTRL 0x24
#define I2C_SLV0_ADDR 0x25
#define I2C_SLV0_REG 0x26
#define I2C_SLV0_DO 0x63
#define I2C_SLV0_CTRL 0x27
#define I2C_SLV0_EN 0x80
#define I2C_READ_FLAG 0x80

#define WHO_AM_I 0x75

// AK8963 registers
#define AK8963_I2C_ADDR 0x0C

#define AK8963_HXL 0x03

#define AK8963_CNTL1 0x0A
#define AK8963_PWR_DOWN 0x00
#define AK8963_CNT_MEAS1 0x12
#define AK8963_CNT_MEAS2 0x16
#define AK8963_FUSE_ROM 0x0F

#define AK8963_CNTL2 0x0B
#define AK8963_RESET 0x01

#define AK8963_ASA 0x10

#define AK8963_WHO_AM_I 0x00


uint8_t writeRegister(uint8_t subAddress, uint8_t data);
void readRegisters(uint8_t subAddress, uint8_t count, uint8_t* dest);
uint8_t writeAK8963Register(uint8_t subAddress, uint8_t data);
void readAK8963Registers(uint8_t subAddress, uint8_t count, uint8_t* dest);
uint8_t whoAmI();
uint8_t whoAmIAK8963();

#endif
