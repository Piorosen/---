#include "LineClass.h"


LineClass::LineClass()
{
	m_vertexBuffer = 0;
	m_indexBuffer = 0;
}


LineClass::LineClass(const LineClass& other)
{
}


LineClass::~LineClass()
{
}


bool LineClass::Initialize(ID3D11Device* device, D3DXVECTOR4 color, D3DXVECTOR3 StartPoint, D3DXVECTOR3 EndPoint, double Thin)
{
	bool result;


	// Initialize the vertex and index buffers.
	result = InitializeBuffers(device, color, StartPoint, EndPoint, Thin);
	if (!result)
	{
		return false;
	}

	return true;
}


void LineClass::Shutdown()
{
	// Shutdown the vertex and index buffers.
	ShutdownBuffers();

	return;
}


void LineClass::Render(ID3D11DeviceContext* deviceContext)
{
	// Put the vertex and index buffers on the graphics pipeline to prepare them for drawing.
	RenderBuffers(deviceContext);

	return;
}


int LineClass::GetIndexCount()
{
	return m_indexCount;
}


bool LineClass::InitializeBuffers(ID3D11Device* device, D3DXVECTOR4 color, D3DXVECTOR3 StartPoint, D3DXVECTOR3 EndPoint, double Thin)
{
	VertexType* vertices;
	unsigned long* indices;
	D3D11_BUFFER_DESC vertexBufferDesc, indexBufferDesc;
	D3D11_SUBRESOURCE_DATA vertexData, indexData;
	HRESULT result;


	// Set the number of vertices in the vertex array.
	m_vertexCount = 6;

	// Set the number of indices in the index array.
	m_indexCount = 6;

	// Create the vertex array.
	vertices = new VertexType[m_vertexCount];
	if (!vertices)
	{
		return false;
	}

	// Create the index array.
	indices = new unsigned long[m_indexCount];
	if (!indices)
	{
		return false;
	}

	double m = (EndPoint.y - StartPoint.y) / (EndPoint.x - StartPoint.x);
	double xd, yd;

	if (m > 0) {
		xd = Thin * cos(3.1415926535897931 / 2 - atan(m));
		yd = Thin * sin(3.1415926535897931 / 2 - atan(m));
	}
	else {
		xd = Thin * cos(3.1415926535897931 / 2 + atan(m));
		yd = Thin * sin(3.1415926535897931 / 2 + atan(m));
	}

	D3DXVECTOR3 point[4];
	
	if (m > 0) {
		point[0] = D3DXVECTOR3(StartPoint.x - xd, StartPoint.y + yd, 0);
		point[1] = D3DXVECTOR3(StartPoint.x + xd, StartPoint.y - yd, 0);
		point[2] = D3DXVECTOR3(EndPoint.x - xd, EndPoint.y + yd, 0);
		point[3] = D3DXVECTOR3(EndPoint.x + xd, EndPoint.y - yd, 0);
	}
	else {
		point[0] = D3DXVECTOR3(StartPoint.x + xd, StartPoint.y + yd, 0);
		point[1] = D3DXVECTOR3(StartPoint.x - xd, StartPoint.y - yd, 0);
		point[2] = D3DXVECTOR3(EndPoint.x + xd, EndPoint.y + yd, 0);
		point[3] = D3DXVECTOR3(EndPoint.x - xd, EndPoint.y - yd, 0);
	}
	
	vertices[0].position = point[0];  // Bottom left.
	vertices[0].color = color;

	vertices[1].position = point[2];  // Top middle.
	vertices[1].color = color;

	vertices[2].position = point[1];  // Bottom right.
	vertices[2].color = color;

	vertices[3].position = point[3];  // Bottom left.
	vertices[3].color = color;

	vertices[4].position = point[1];  // Top middle.
	vertices[4].color = color;

	vertices[5].position = point[2];  // Bottom right.
	vertices[5].color = color;
	if (StartPoint.x - EndPoint.x < 0) {
		// Load the index array with data.
		// Load the index array with data.
		indices[0] = 0;  // 0
		indices[1] = 1;  // 2
		indices[2] = 2;  // 1
		indices[3] = 3;  // 3
		indices[4] = 4;  // 1
		indices[5] = 5;  // 2
	}
	else {
		indices[0] = 2;  // 0
		indices[1] = 1;  // 2
		indices[2] = 0;  // 1
		indices[3] = 5;  // 3
		indices[4] = 4;  // 1
		indices[5] = 3;  // 2
	}
					 // Set up the description of the static vertex buffer.
	vertexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
	vertexBufferDesc.ByteWidth = sizeof(VertexType) * m_vertexCount;
	vertexBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	vertexBufferDesc.CPUAccessFlags = 0;
	vertexBufferDesc.MiscFlags = 0;
	vertexBufferDesc.StructureByteStride = 0;

	// Give the subresource structure a pointer to the vertex data.
	vertexData.pSysMem = vertices;
	vertexData.SysMemPitch = 0;
	vertexData.SysMemSlicePitch = 0;

	// Now create the vertex buffer.
	result = device->CreateBuffer(&vertexBufferDesc, &vertexData, &m_vertexBuffer);
	if (FAILED(result))
	{
		return false;
	}

	// Set up the description of the static index buffer.
	indexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
	indexBufferDesc.ByteWidth = sizeof(unsigned long) * m_indexCount;
	indexBufferDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
	indexBufferDesc.CPUAccessFlags = 0;
	indexBufferDesc.MiscFlags = 0;
	indexBufferDesc.StructureByteStride = 0;

	// Give the subresource structure a pointer to the index data.
	indexData.pSysMem = indices;
	indexData.SysMemPitch = 0;
	indexData.SysMemSlicePitch = 0;

	// Create the index buffer.
	result = device->CreateBuffer(&indexBufferDesc, &indexData, &m_indexBuffer);
	if (FAILED(result))
	{
		return false;
	}

	// Release the arrays now that the vertex and index buffers have been created and loaded.
	delete[] vertices;
	vertices = 0;

	delete[] indices;
	indices = 0;

	return true;
}


void LineClass::ShutdownBuffers()
{
	// Release the index buffer.
	if (m_indexBuffer)
	{
		m_indexBuffer->Release();
		m_indexBuffer = 0;
	}

	// Release the vertex buffer.
	if (m_vertexBuffer)
	{
		m_vertexBuffer->Release();
		m_vertexBuffer = 0;
	}

	return;
}


void LineClass::RenderBuffers(ID3D11DeviceContext* deviceContext)
{
	unsigned int stride;
	unsigned int offset;

	// Set vertex buffer stride and offset.
	stride = sizeof(VertexType);
	offset = 0;

	// Set the vertex buffer to active in the input assembler so it can be rendered.
	deviceContext->IASetVertexBuffers(0, 1, &m_vertexBuffer, &stride, &offset);

	// Set the index buffer to active in the input assembler so it can be rendered.
	deviceContext->IASetIndexBuffer(m_indexBuffer, DXGI_FORMAT_R32_UINT, 0);

	// Set the type of primitive that should be rendered from this vertex buffer, in this case triangles.
	deviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

	return;
}