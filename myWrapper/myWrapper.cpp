
#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <Windows.h>

#ifdef _MANAGED
#pragma managed(push, off)
#endif

//#pragma comment(lib, "MU_3SL_interface_64.lib")
#include "MU_3SL_defs.h"
#include "MU_3SL_interface.h"

extern "C" __declspec(dllexport) MU_Error callGetLastError(MU_Handle handle, MU_Error* lastErrorNo, MU_ErrorType* lastErrorType, char* lastErrorText);
extern "C" __declspec(dllexport) unsigned long getAnalyzeResultLogSize(const MU_CalibrationAnalyzeResult* analyzeResult);
extern "C" __declspec(dllexport) void getAnalyzeResultLogMsg(const MU_CalibrationAnalyzeResult* analyzeResult, unsigned long size, char* RltMsg);
extern "C" __declspec(dllexport) bool printAnalogAnalyzeResultAdjustableLog(const MU_Calibration* calibration, const MU_CalibrationAnalyzeResult* analyzeResult, char* RltMsg);
extern "C" __declspec(dllexport) int8_t getOptimizedNoniusTrackOffsetTable(const MU_CalibrationAnalyzeResult* analyzeResult, int8_t* table);
extern "C" __declspec(dllexport) bool setCurrentNoniusTrackOffsetTable(MU_Calibration* calibration, const MU_CalibrationAnalyzeResult* analyzeResult);
extern "C" __declspec(dllexport) void getNoniusPhaseError(const MU_CalibrationAnalyzeResult* analyzeResult, long* data);
extern "C" __declspec(dllexport) void getNoniusTrackOffsetCurve(const MU_CalibrationAnalyzeResult* analyzeResult, long* data);
extern "C" __declspec(dllexport) void getnoniusPhaseMargin(const MU_CalibrationAnalyzeResult* analyzeResult, long* data);
extern "C" __declspec(dllexport) MU_Error MU_WriteParams2(MU_Handle handle);
extern "C" __declspec(dllexport) MU_Error MU_acquireRawData2(MU_Handle handle, uint16_t* masterRawData, uint16_t* noniusRawData, size_t nSamples, uint32_t slaveId, double frameCycleTime_s, double clockFreq_hz);
extern "C" __declspec(dllexport) uint32_t MU_readSens2(MU_Handle handle);

extern "C" __declspec(dllexport) MU_Error callGetLastError(MU_Handle handle, MU_Error* lastErrorNo, MU_ErrorType* lastErrorType, char* lastErrorText)
{
	MU_Error rtn;
	char Text[1024] = { 0, };

	rtn = MU_GetLastError(handle, lastErrorNo, lastErrorType, Text);
	strcpy_s(lastErrorText, 1024, Text);
	return rtn;
}

extern "C" __declspec(dllexport) unsigned long getAnalyzeResultLogSize(const MU_CalibrationAnalyzeResult* analyzeResult)
{
	unsigned long Size = (unsigned long)MU_Calibration_getAnalyzeResultLog(analyzeResult, NULL, 0, 7) + 1;
	return Size;
}

extern "C" __declspec(dllexport) void getAnalyzeResultLogMsg(const MU_CalibrationAnalyzeResult* analyzeResult, unsigned long size, char* RltMsg)
{
	char* RltLogMsg = (char*)malloc(size * sizeof(char));
	MU_Calibration_getAnalyzeResultLog(analyzeResult, RltLogMsg, size, 7);
	strcpy_s(RltMsg, 4096, RltLogMsg);
	free(RltLogMsg);
}

extern "C" __declspec(dllexport) bool printAnalogAnalyzeResultAdjustableLog(const MU_Calibration* calibration, const MU_CalibrationAnalyzeResult* analyzeResult, char* RltMsg)
{
	char adjustmentMsg[1024];
	bool isAdjustable = MU_Calibration_isAnalogAnalyzeResultAdjustable(
		calibration, analyzeResult, adjustmentMsg, 1024, 7);
	strcpy_s(RltMsg, 1024, adjustmentMsg);
	return isAdjustable;
}

extern "C" __declspec(dllexport) int8_t getOptimizedNoniusTrackOffsetTable(const MU_CalibrationAnalyzeResult* analyzeResult, int8_t* table)
{
	MU_Calibration_NoniusTrackOffsetTable noniusTrackOffsetTable;
	MU_Calibration_getOptimizedNoniusTrackOffsetTable(analyzeResult, &noniusTrackOffsetTable);
	memcpy(table, &noniusTrackOffsetTable.spoN, sizeof(int8_t) * 16);
	int8_t rtn = noniusTrackOffsetTable.spoBase;
	return rtn;
}

extern "C" __declspec(dllexport) bool setCurrentNoniusTrackOffsetTable(MU_Calibration* calibration, const MU_CalibrationAnalyzeResult* analyzeResult)
{
	MU_Calibration_NoniusTrackOffsetTable optimizedNoniusTrackOffsetTable;
	MU_Calibration_getOptimizedNoniusTrackOffsetTable(analyzeResult, &optimizedNoniusTrackOffsetTable);
	bool ret = MU_Calibration_setCurrentNoniusTrackOffsetTable(calibration, &optimizedNoniusTrackOffsetTable);
	return ret;
}

extern "C" __declspec(dllexport) void getNoniusPhaseError(const MU_CalibrationAnalyzeResult* analyzeResult, long* data)
{
	size_t numberOfNoniusCurveSamples =
		MU_Calibration_numberOfNoniusCurveSamples(analyzeResult);
	const long* noniusPhaseErrorData = MU_Calibration_noniusPhaseError(analyzeResult);
	memcpy(data, noniusPhaseErrorData, numberOfNoniusCurveSamples * sizeof(long));
}

extern "C" __declspec(dllexport) void getNoniusTrackOffsetCurve(const MU_CalibrationAnalyzeResult* analyzeResult, long* data)
{
	size_t numberOfNoniusCurveSamples =
		MU_Calibration_numberOfNoniusCurveSamples(analyzeResult);
	const long* noniusTrackOffsetCurveData = MU_Calibration_noniusTrackOffsetCurve(analyzeResult);
	memcpy(data, noniusTrackOffsetCurveData, numberOfNoniusCurveSamples * sizeof(long));
}

extern "C" __declspec(dllexport) void getnoniusPhaseMargin(const MU_CalibrationAnalyzeResult* analyzeResult, long* data)
{
	size_t numberOfNoniusCurveSamples =
		MU_Calibration_numberOfNoniusCurveSamples(analyzeResult);
	const long* noniusPhaseMarginData = MU_Calibration_noniusPhaseMargin(analyzeResult);
	memcpy(data, noniusPhaseMarginData, numberOfNoniusCurveSamples * sizeof(long));
}

extern "C" __declspec(dllexport) MU_Error MU_WriteParams2(MU_Handle handle)
{
	//bool rlt[128];
	MU_Error rtn = MU_WriteParams(handle, false, NULL);
	//MU_Error rtn = MU_WriteParams(handle, true, rlt);
	return rtn;
}

extern "C" __declspec(dllexport) MU_Error MU_acquireRawData2(MU_Handle handle, uint16_t* masterRawData, uint16_t* noniusRawData, size_t nSamples, uint32_t slaveId, double frameCycleTime_s, double clockFreq_hz)
{
	MU_Error rtn;
	uint16_t* master = (uint16_t*)malloc(nSamples * sizeof(uint16_t));
	uint16_t* nonius = (uint16_t*)malloc(nSamples * sizeof(uint16_t));

	rtn = MU_acquireRawData(handle, master, nonius, nSamples, slaveId, frameCycleTime_s, clockFreq_hz);
	memcpy(masterRawData, master, nSamples * sizeof(uint16_t));
	memcpy(noniusRawData, nonius, nSamples * sizeof(uint16_t));

	free(master);
	free(nonius);
	return rtn;
}

extern "C" __declspec(dllexport) uint32_t MU_readSens2(MU_Handle handle)
{
	MU_Error rtn;
	ReadSensStruct sens;
	rtn = MU_ReadSens(handle, &sens);
	return sens.st;
}