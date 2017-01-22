### Credits ###
We use this [library for MPU-9250](https://github.com/bolderflight/MPU9250) implemented by Brian R Taylor.

### Troubleshooting ###

#### SPI Communication ####
* No Data feedback
To properly write and then read out ONE BYTE into/from MPU9250 registers you need to perform precisely the following steps:
  1. Transfer 1 byte address (SPI TX)
  2. Transfer 1 byte value   (SPI TX)
  3. Transfer 1 byte (address | 0x80) - 0x80 flag of reading
  4. In full duplex mode Transfer 0x00 (RX+TX 0x00)

  On the last step it is important to put 0x00 into SPI MOSI line. Otherwise it seems like MPU9250 thinks that you write or something else. Anyway, you won't receive good data if you don't send 0x00 in full duplex mode.

  ![SPI communication](assets/posts/img/SPI_fullduplex_issue.png "Example of wrong and correct SPI communication")