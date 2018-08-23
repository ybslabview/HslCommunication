﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HslCommunication;

namespace HslCommunication_Net45.Test.Profinet.Melsec
{
    [TestClass]
    public class MelsecFxSerialTest
    {
        [TestMethod]
        public void BuildWriteBoolPacketTest( )
        {
            // 测试生成的指令是否是正确的
            byte[] corrent = new byte[] { 0x02, 0x37, 0x31, 0x33, 0x30, 0x35, 0x03, 0x30, 0x33 };
            OperateResult<byte[]> operateResult = HslCommunication.Profinet.Melsec.MelsecFxSerial.BuildWriteBoolPacket( "Y23", true );
            Assert.IsTrue( operateResult.IsSuccess, "Y23指令生成失败" );
            Assert.IsTrue( HslCommunication.BasicFramework.SoftBasic.IsTwoBytesEquel( corrent, operateResult.Content ), "Y23指令校验失败" );

            corrent = new byte[] { 0x02, 0x37, 0x31, 0x31, 0x30, 0x38, 0x03, 0x30, 0x34 };
            operateResult = HslCommunication.Profinet.Melsec.MelsecFxSerial.BuildWriteBoolPacket( "M17", true );
            Assert.IsTrue( operateResult.IsSuccess, "M17指令生成失败" );
            Assert.IsTrue( HslCommunication.BasicFramework.SoftBasic.IsTwoBytesEquel( corrent, operateResult.Content ), "M17指令校验失败" );

            corrent = new byte[] { 0x02, 0x38, 0x31, 0x31, 0x30, 0x38, 0x03, 0x30, 0x35 };
            operateResult = HslCommunication.Profinet.Melsec.MelsecFxSerial.BuildWriteBoolPacket( "M17", false );
            Assert.IsTrue( operateResult.IsSuccess, "M17指令生成失败" );
            Assert.IsTrue( HslCommunication.BasicFramework.SoftBasic.IsTwoBytesEquel( corrent, operateResult.Content ), "M17指令校验失败" );
        }

        [TestMethod]
        public void BuildReadWordCommandTest( )
        {
            byte[] corrent = new byte[] { 0x02, 0x30, 0x30, 0x30, 0x41, 0x30, 0x30, 0x32, 0x03, 0x36, 0x36 };
            OperateResult<byte[],int> operateResult = HslCommunication.Profinet.Melsec.MelsecFxSerial.BuildReadBoolCommand( "Y0", 16 );
            Assert.IsTrue( operateResult.IsSuccess, "Y0指令生成失败" );
            Assert.IsTrue( HslCommunication.BasicFramework.SoftBasic.IsTwoBytesEquel( corrent, operateResult.Content1 ), "Y23指令校验失败" );

            corrent = new byte[] { 0x02, 0x30, 0x31, 0x30, 0x46, 0x36, 0x30, 0x34, 0x03, 0x37, 0x34 };
            OperateResult<byte[]> read = HslCommunication.Profinet.Melsec.MelsecFxSerial.BuildReadWordCommand( "D123", 2 );
            Assert.IsTrue( operateResult.IsSuccess, "D123指令生成失败" );
            Assert.IsTrue( HslCommunication.BasicFramework.SoftBasic.IsTwoBytesEquel( corrent, read.Content ), "D123指令校验失败" );
        }



    }
}