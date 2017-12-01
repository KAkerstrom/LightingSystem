namespace LightTest.Kyle
{
    /// <summary>
    /// The command codes.
    /// </summary>
    enum Commands : byte
    {
        ///<summary>
        ///Change the Node Number to a new value
        ///</summary>
        CmdSysPNodeNum = 0x00,

        ///<summary>
        ///Response to a change in the Node ID.
        ///</summary>
        CmdSysPNodeNumResponse = 0x01,
        
        ///<summary>
        ///Ping the board to see if it's present
        ///</summary>
        CmdSysPing = 0x02,

        ///<summary>
        ///Respond to ping with type and version #
        ///</summary>
        CmdSysPong = 0x03,

        ///<summary>
        ///Program the first 7 characters of the name
        ///</summary>
        CmdSysPName1 = 0x04,

        ///<summary>
        ///Enquire as to the current first 7 characters of the name.
        ///</summary>
        CmdSysEName1 = 0x06,

        ///<summary>
        ///Response to enquiry as to first 7 characters of the name (actual data written).
        ///</summary>
        CmdSysRName1 = 0x07,

        ///<summary>
        ///Program the second 7 characters of the name
        ///</summary>
        CmdSysPName2 = 0x08,

        ///<summary>
        ///Enquire as to the current value of the second 7 characters of the name.
        ///</summary>
        CmdSysEName2 = 0x0A,

        ///<summary>
        ///Response to enquiry as to the second 7 characters of the name (actual data written).
        ///</summary>
        CmdSysRName2 = 0x0B,

        ///<summary>
        ///Program the third 7 characters of the name
        ///</summary>
        CmdSysPName3 = 0x0C,

        ///<summary>
        ///Enquire as to the third 7 characters of the name
        ///</summary>
        CmdSysEName3 = 0x0E,

        ///<summary>
        ///Response to enquiry as to the third 7 characters of the name (actual data written).
        ///</summary>
        CmdSysRName3 = 0x0F,

        ///<summary>
        ///Parameter settings, each is defined separately
        ///</summary>
        CmdSysPPar = 0x10,

        ///<summary>
        ///Enquire as to the current parameter setting(s)
        ///</summary>
        CmdSysEPar = 0x12,

        ///<summary>
        ///Response to both the above.
        ///</summary>
        CmdSysRPar = 0x13,

        ///<summary>
        ///Unlock memory to change parameters
        ///</summary>
        CmdSysPLock = 0x1A,

        ///<summary>
        ///Enquire the state of memory lock
        ///</summary>
        CmdSysELock = 0x1C,

        ///<summary>
        ///Response to above
        ///</summary>
        CmdSysRLock = 0x1D,

        ///<summary>
        ///Program current state of device (used to start a process)
        ///</summary>
        CmdSysPState = 0x1F,

        ///<summary>
        ///Enquire current state
        ///</summary>
        CmdSysEState = 0x20,

        ///<summary>
        ///Response to above
        ///</summary>
        CmdSysRState = 0x21,

        ///<summary>
        ///Parameter settings, each is defined separately
        ///</summary>
        CmdSysPPar2 = 0x22,

        ///<summary>
        ///Enquire as to the current setting(s)
        ///</summary>
        CmdSysEPar2 = 0x24,

        ///<summary>
        ///Response to both the above. 
        ///</summary>
        CmdSysRPar2 = 0x25,

        ///<summary>
        ///Program a raw value into the device (depends on device type)
        ///</summary>
        CmdSysPRawVal = 0x2A,

        ///<summary>
        ///Enquire raw value
        ///</summary>
        CmdSysERawVal = 0x2C,

        ///<summary>
        ///Response to above
        ///</summary>
        CmdSysRRawVal = 0x2D,

        ///<summary>
        ///Request a device to send their current state to zero,zero
        ///</summary>
        CmdSysEStateZZ = 0x2E,

        ///<summary>
        ///Toggle between On/Off
        ///</summary>
        CmdConOnOff = 0x30,

        ///<summary>
        ///Double Click
        ///</summary>
        CmdConDClk = 0x31,

        ///<summary>
        ///Hold and fade up and down continuously
        ///</summary>
        CmdConFadeCont = 0x32,

        ///<summary>
        ///Used to set the preset value
        ///</summary>
        CmdConRelease = 0x33,

        ///<summary>
        ///Go directly to a value 0-100%.
        ///Requires a brightness value from 0x00 - 0x64 as a data parameter.
        ///</summary>
        CmdConValue = 0x34,

        ///<summary>
        ///Fade to light level over time.
        ///</summary>
        CmdConSetFade = 0x35,

        ///<summary>
        ///Fade up but stop at brightest
        ///</summary>
        CmdConFadeUp = 0x36,

        ///<summary>
        ///Fade down but stop at lowest
        ///</summary>
        CmdConFadeDwn = 0x37,

        ///<summary>
        ///Used to go to a preset level
        ///</summary>
        CmdConOn = 0x38,

        ///<summary>
        ///Used to go to an off setting
        ///</summary>
        CmdConOff = 0x39,

        ///<summary>
        ///Execute a scene stored in a scene processor
        ///</summary>
        CmdConExecScene = 0x3A,

        ///<summary>
        ///Transmit a change of state to zero, zero
        ///</summary>
        CmdStatLightValue = 0x50,

        ///<summary>
        ///Transmit an error or warning to zero, zero
        ///</summary>
        CmdStatError = 0x51,

        ///<summary>
        ///(Prog) Erase memory when flashing new firmware * Both Secure and UnSecure Cheetah12
        ///</summary>
        FlashPErase = 0x90,

        ///<summary>
        ///(Resp) Erase memory when flashing new firmware * Both Secure and UnSecure Cheetah12
        ///</summary>
        FlashRErase = 0x91,

        ///<summary>
        ///(Prog) Program encrypted data *Secure Cheetah12
        ///</summary>
        FlashPEncryptData = 0x92,

        ///<summary>
        ///(Resp) Response to encrypted data * Secure Cheetah12
        ///</summary>
        FlashREncryptData = 0x93,

        ///<summary>
        ///(Prog) write 16 bit word when flashing new firmware * Both Secure and UnSecure Cheetah12
        ///</summary>
        FlashPWordWrite = 0x94,

        ///<summary>
        ///(Resp) write 16 bit word when flashing new firmware * Both Secure and UnSecure Cheetah12
        ///</summary>
        FlashRWordWrite = 0x95,

        ///<summary>
        ///(Enq ) Read a block of memory when flashing new firmware * Both Secure and UnSecure Cheetah12
        ///</summary>
        FlashEWordRead = 0x96,

        ///<summary>
        ///(Resp) Read a block of memory when flashing new firmware * Both Secure and UnSecure Cheetah12
        ///</summary>
        FlashRWordRead = 0x97,

        ///<summary>
        ///(Prog) Restart the processor after flashing new firmware * Both
        ///</summary>
        FlashPReBoot = 0x98,

        ///<summary>
        ///(Resp) Restart the processor after flashing new firmware* Both
        ///</summary>
        FlashRReBoot = 0x99,

        ///<summary>
        ///(Prog) Verify the contents of the flash memory integrity * Secure
        ///</summary>
        FlashPVerify = 0x9A,

        ///<summary>
        ///(Resp) Response to verify 1=failed, 2=passed *Secure
        ///</summary>
        FlashRVerify = 0x9B,

        ///<summary>
        ///(Prog) change Brightan module to flash download from within running program *Secure
        ///</summary>
        FlashPStartFlash = 0x9C,

        ///<summary>
        ///(Resp) Response, only sent on failure * Secure
        ///</summary>
        FlashRStartFlash = 0x9D,

        ///<summary>
        ///expansion command with Long Index, Program
        ///</summary>
        CmdSysPExpLInd = 0xA0,

        ///<summary>
        ///ditto for Enquire
        ///</summary>
        CmdSysEExpLInd = 0xA1,

        ///<summary>
        ///ditto for Response
        ///</summary>
        CmdSysRExpLInd = 0xA2,

        ///<summary>
        ///expansion command with Short Index, Program
        ///</summary>
        CmdSysPExpSInd = 0xA3,

        ///<summary>
        ///ditto for Enquire
        ///</summary>
        CmdSysEExpSInd = 0xA4,

        ///<summary>
        ///ditto for Response
        ///</summary>
        CmdSysRExpSInd = 0xA5,

        ///<summary>
        ///Diagnostic message request
        ///</summary>
        CmdSysEDiag = 0xF0,

        ///<summary>
        ///Diagnostic message response
        ///</summary>
        CmdSysRDiag = 0xF1,
    }
}
