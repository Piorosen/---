#pragma once

#include <D3DX10math.h>


class Character {
private:

public:
	virtual void Shutdown() = 0;
	virtual void Move(ID3D11DeviceContext*, D3DXVECTOR2 data,
		D3DXMATRIX w, D3DXMATRIX v, D3DXMATRIX o) = 0;

protected:
	D3DXVECTOR2 Position;
	int HealthPoint;
};